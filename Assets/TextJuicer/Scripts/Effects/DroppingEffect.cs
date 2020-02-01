using UnityEngine;
namespace BrunoMikoski.TextJuicer.Effects
{
    [AddComponentMenu("UI/Text Juicer/Effects/DroppingEffect")]
    public class DroppingEffect : VertexModifier
    {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(1, 1));
        [SerializeField]
        private AnimationCurve colorCurve = new AnimationCurve(new Keyframe(0, 0));

        [SerializeField]
        private Color[] colors;

        public override void Apply(CharacterData characterData, ref UIVertex uiVertex)
        {
            uiVertex.position.y *= curve.Evaluate(characterData.Progress);
            uiVertex.position.x *= curve.Evaluate(characterData.Progress);

            Color targetColor = colors[characterData.Order % colors.Length];
            Color currentColor = uiVertex.color;


            targetColor = targetColor * colorCurve.Evaluate(characterData.Progress);
            currentColor = currentColor * (1f - colorCurve.Evaluate(characterData.Progress));

            uiVertex.color = currentColor + targetColor;
        }
    }
}
