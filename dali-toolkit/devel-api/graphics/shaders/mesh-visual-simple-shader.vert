#version 430

layout(location=0) in vec3 aPosition;
layout(location=1) in vec3 aNormal;

layout(location=0) out mediump vec3 vIllumination;

layout(set=0, binding=0, std140) uniform VertData
{
    mediump vec3 uSize;
    mediump mat4 uMvpMatrix;
    mediump mat4 uModelView;
    mediump mat4 uViewMatrix;
    mediump mat3 uNormalMatrix;
    mediump mat4 uObjectMatrix;
    mediump vec3 lightPosition;
    mediump vec2 uStageOffset;

    //Visual size and offset
    mediump vec2 offset;
    mediump vec2 size;
    mediump vec4 offsetSizeMode;
    mediump vec2 origin;
    mediump vec2 anchorPoint;
};

vec4 ComputeVertexPosition()
{
    vec2 visualSize = mix(uSize.xy*size, size, offsetSizeMode.zw );
    float scaleFactor = min( visualSize.x, visualSize.y );
    vec3 originFlipY =  vec3(origin.x, -origin.y, 0.0);
    vec3 anchorPointFlipY = vec3( anchorPoint.x, -anchorPoint.y, 0.0);
    vec3 offset = vec3( ( offset / uSize.xy ) * offsetSizeMode.xy + offset * (1.0-offsetSizeMode.xy), 0.0) * vec3(1.0,-1.0,1.0);
    return vec4( (aPosition + anchorPointFlipY)*scaleFactor + (offset + originFlipY)*uSize, 1.0 );
}

void main()
{
    vec4 normalisedVertexPosition = ComputeVertexPosition();
    vec4 vertexPosition = uObjectMatrix * normalisedVertexPosition;
    vertexPosition = uMvpMatrix * vertexPosition;

    //Illumination in Model-View space - Transform attributes and uniforms
    vec4 mvVertexPosition = uModelView * normalisedVertexPosition;
    vec3 normal = uNormalMatrix * mat3( uObjectMatrix ) * aNormal;

    vec4 mvLightPosition = vec4( ( lightPosition.xy - uStageOffset ), lightPosition.z, 1.0 );
    mvLightPosition = uViewMatrix * mvLightPosition;
    vec3 vectorToLight = normalize( mvLightPosition.xyz - mvVertexPosition.xyz );

    float lightDiffuse = max( dot( vectorToLight, normal ), 0.0 );
    vIllumination = vec3( lightDiffuse * 0.5 + 0.5 );

    gl_Position = vertexPosition;
}