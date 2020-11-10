Shader "Unlit/Hologram"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "red" {}
        _TintColor("Tint Color", Color) = (1,1,1,1)
        _Transparency("Transparency",Range(0.0 , 0.5)) = 0.25
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha



        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag            

            #include "UnityCG.cginc"


            //Les structures sont des objets qui contiennent des variables
            //Appdata contient les variavle pour les certex du modèle 3D et les coodronnées des UV
            struct appdata
            {
                float4 vertex : POSITION; //Float4 = un tableau de 4 float ( dans ce cas il s'agit de x,y,z,w ) ici c'est la position dans le monde
                float2 uv : TEXCOORD0; 
            };
            

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION; //Ici c'est la position à l'affichage de l'écran
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _Transparency;

            //Ceci est une fonction
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            //Ceci est une fonction
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;//Ceci est pour une couleur //On ajoute une deuxième couleur
            col.a = _Transparency;
                return col;
            }
            ENDCG
        }
    }
}
