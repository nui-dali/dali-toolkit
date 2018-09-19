#version 430

layout( location=0 ) in mediump vec2 vTexCoord;

layout(set=1, binding=0, std140) uniform FragData
{
  mediump vec4 uAtlasRect;
  lowp vec2 wrapMode;
  lowp vec4 uColor;
  lowp vec3 mixColor;
  lowp float preMultipliedAlpha;
};

layout(set=1, binding=1) uniform sampler2D sTexture;

layout(location=0) out vec4 fragColor;

mediump float wrapCoordinate( vec2 range, float coordinate, float wrap )
{
  mediump float coord;
  if( wrap > 1.5 ) // REFLECT
    coord = 1.0-abs(fract(coordinate*0.5)*2.0 - 1.0);
  else // warp == 0 or 1
    coord = mix(coordinate, fract( coordinate ), wrap);
  return clamp( mix(range.x, range.y, coord), range.x, range.y );
}

void main()
{
  mediump vec2 texCoord = vec2( wrapCoordinate( uAtlasRect.xz, vTexCoord.x, wrapMode.x ),
                                  wrapCoordinate( uAtlasRect.yw, vTexCoord.y, wrapMode.y ) );
  fragColor = texture( sTexture, texCoord ) * uColor * vec4(mixColor,1.0);
}