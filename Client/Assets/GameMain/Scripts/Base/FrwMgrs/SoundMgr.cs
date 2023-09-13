

using DataTable;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Sound;
using GameMain.Game;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
        public class SoundMgr:Singleton<SoundMgr>
    {
        private const float FadeVolumeDuration = 1f;
        private int? s_MusicSerialId = null;

        public  int? PlayMusic(int musicId, object userData = null)
        {
            StopMusic();

            IDataTable<DTMusic> dtMusic = DataTableMgr.Instance.GetDataTable<DTMusic>();
            DTMusic drMusic = dtMusic.GetDataRow(musicId);
            if (drMusic == null)
            {
                Log.Warning("Can not load music '{0}' from data table.", musicId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 64;
            playSoundParams.Loop = true;
            playSoundParams.VolumeInSoundGroup = 1f;
            playSoundParams.FadeInSeconds = FadeVolumeDuration;
            playSoundParams.SpatialBlend = 0f;
            s_MusicSerialId = GameCompMgr.Sound.PlaySound(AssetPathUtils.GetMusicAsset(drMusic.AssetName), "Music", Constant.AssetPriority.MusicAsset, playSoundParams, null, userData);
            return s_MusicSerialId;
        }

        public  void StopMusic()
        {
            if (!s_MusicSerialId.HasValue)
            {
                return;
            }

            GameCompMgr.Sound.StopSound(s_MusicSerialId.Value, FadeVolumeDuration);
            s_MusicSerialId = null;
        }

        public  int? PlaySound(int soundId, EntityLg bindingEntity = null, object userData = null)
        {
            IDataTable<DTSound> dtSound = DataTableMgr.Instance.GetDataTable<DTSound>();
            DTSound drSound = dtSound.GetDataRow(soundId);
            if (drSound == null)
            {
                Log.Warning("Can not load sound '{0}' from data table.", soundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = drSound.Priority;
            playSoundParams.Loop = drSound.Loop;
            playSoundParams.VolumeInSoundGroup = drSound.Volume;
            playSoundParams.SpatialBlend = drSound.SpatialBlend;
            return GameCompMgr.Sound.PlaySound(AssetPathUtils.GetSoundAsset(drSound.AssetName), "Sound", Constant.AssetPriority.SoundAsset, playSoundParams, bindingEntity != null ? bindingEntity.Entity : null, userData);
        }

        public  int? PlayUISound(int uiSoundId, object userData = null)
        {
            IDataTable<DTUISound> dtUISound = DataTableMgr.Instance.GetDataTable<DTUISound>();
            DTUISound drUISound = dtUISound.GetDataRow(uiSoundId);
            if (drUISound == null)
            {
                Log.Warning("Can not load UI sound '{0}' from data table.", uiSoundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = drUISound.Priority;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = drUISound.Volume;
            playSoundParams.SpatialBlend = 0f;
            return GameCompMgr.Sound.PlaySound(AssetPathUtils.GetUISoundAsset(drUISound.AssetName), "UISound", Constant.AssetPriority.UISoundAsset, playSoundParams, userData);
        }

        public  bool IsMuted(string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return true;
            }

            ISoundGroup soundGroup = GameCompMgr.Sound.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return true;
            }

            return soundGroup.Mute;
        }

        public  void Mute(string soundGroupName, bool mute)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            ISoundGroup soundGroup = GameCompMgr.Sound.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Mute = mute;

            SettingMgr.Instance.SetBool(Utility.Text.Format(Constant.Setting.SoundGroupMuted, soundGroupName), mute);
            SettingMgr.Instance.Save();
        }

        public  float GetVolume(string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return 0f;
            }

            ISoundGroup soundGroup = GameCompMgr.Sound.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return 0f;
            }

            return soundGroup.Volume;
        }

        public  void SetVolume(string soundGroupName, float volume)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            ISoundGroup soundGroup = GameCompMgr.Sound.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Volume = volume;

            SettingMgr.Instance.SetFloat(Utility.Text.Format(Constant.Setting.SoundGroupVolume, soundGroupName), volume);
            SettingMgr.Instance.Save();
        }

        public void StopAllSounds()
        {
            GameCompMgr.Sound.StopAllLoadedSounds();
            GameCompMgr.Sound.StopAllLoadingSounds();
        }
    }
}