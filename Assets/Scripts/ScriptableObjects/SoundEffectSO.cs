// using Sirenix.OdinInspector;

using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSoundEffect", menuName = "ScriptableObjects/New Sound Effect")]
    public class SoundEffectSO : ScriptableObject
    {
        // #region config
        public GameObject _sourcePrefab;
        // private static readonly float SEMITONES_TO_PITCH_CONVERSION_UNIT = 1.05946f;

        public AudioClip clip;
        // public AudioClip[] clips;
        public bool Loop;

        // [MinMaxSlider(0, 1)] [BoxGroup("config")]
        public float volume = 1;

        //Pitch / Semitones
        // [LabelWidth(100)] [HorizontalGroup("config/pitch")]
        // public bool useSemitones;

        // [HideLabel]
        // [ShowIf("useSemitones")]
        // [HorizontalGroup("config/pitch")]
        // [MinMaxSlider(-10, 10)]
        // [OnValueChanged("SyncPitchAndSemitones")]
        // public Vector2Int semitones = new Vector2Int(0, 0);

        // [HideLabel]
        // [HideIf("useSemitones")]
        // [MinMaxSlider(0, 3)]
        // [HorizontalGroup("config/pitch")]
        // [OnValueChanged("SyncPitchAndSemitones")]
        // public Vector2 pitch = new Vector2(1, 1);

        // [SerializeField] private SoundClipPlayOrder playOrder;

        // [DisplayAsString] [BoxGroup("config")] [SerializeField]
        // private int playIndex = 0;

        // #endregion

        // #region PreviewCode
        
        // private AudioSource previewer;

        // private void OnEnable()
        // {
        //     previewer = EditorUtility
        //         .CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave,
        //             typeof(AudioSource))
        //         .GetComponent<AudioSource>();
        // }

        private void OnDisable()
        {
            // DestroyImmediate(previewer.gameObject);
        }

        // private AudioClip GetAudioClip()
        // {
        //     // get current clip
        //     var clip = clips[playIndex >= clips.Length ? 0 : playIndex];
        //
        //     // find next clip
        //     switch (playOrder)
        //     {
        //         case SoundClipPlayOrder.in_order:
        //             playIndex = (playIndex + 1) % clips.Length;
        //             break;
        //         case SoundClipPlayOrder.random:
        //             playIndex = Random.Range(0, clips.Length);
        //             break;
        //         case SoundClipPlayOrder.reverse:
        //             playIndex = (playIndex + clips.Length - 1) % clips.Length;
        //             break;
        //     }
        //
        //     // return clip
        //     return clip;
        // }

        public void Play()
        {
            if(clip == null) return;
            
            // if (clips.Length == 0)
            // {
            //     // this.LogWarning($"Missing sound clips for {name}");
            //     // return null;
            //     return;
            // }

            var sourceObj = Instantiate(_sourcePrefab);
            var source = sourceObj.GetComponent<AudioSource>();
            
            // var source = audioSourceParam;
            // if (source == null)
            // {
            //     var obj = new GameObject("Sound", typeof(AudioSource));
            //     source = obj.GetComponent<AudioSource>();
            // }

            source.clip = clip;
            // source.clip = GetAudioClip();
            source.volume = volume;
            source.loop = Loop;

            source.Play();
            
            //Destroy when finished
            Destroy(source.gameObject, source.clip.length / source.pitch);
// #endif
            // return source;
        }

        enum SoundClipPlayOrder
        {
            random,
            in_order,
            reverse
        }
    }
}