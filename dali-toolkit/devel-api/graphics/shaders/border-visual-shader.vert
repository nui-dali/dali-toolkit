#version 430

// in variables
layout( location = 0 ) in mediump vec2 aPosition;
layout( location = 1 ) in mediump vec2 aDrift;
  
layout( set = 0, binding = 0, std140 )uniform VertexData
{
  mediump mat4 uMvpMatrix;
  mediump vec3 uSize;
  mediump float borderSize;
  
  // Visual size and offset
  mediump vec2 offset;
  mediump vec2 size;
  mediump vec4 offsetSizeMode;
  mediump vec2 origin;
  mediump vec2 anchorPoint;
};

vec2 ComputeVertexPosition()
{
  vec2 visualSize = mix(uSize.xy*size, size, offsetSizeMode.zw );
  vec2 visualOffset = mix( offset, offset/uSize.xy, offsetSizeMode.xy);
  return (aPosition + anchorPoint)*visualSize + (visualOffset + origin)*uSize.xy;
}

void main()
{
  vec2 position = ComputeVertexPosition() + aDrift*borderSize;
  gl_Position = uMvpMatrix * vec4(position, 0.0, 1.0);
}