using UnityEngine;

public class BrainAnimation : MonoBehaviour
{
    [Header("Animation Component")]
    public Animation anim;

    [Header("Clips")]
    public AnimationClip openClip;
    public AnimationClip showPartsClip;
    public AnimationClip closeClip;

    public void PlayOpen()
    {
        PlayClip(openClip);
    }

    public void PlayShowParts()
    {
        PlayClip(showPartsClip);
    }

    public void PlayClose()
    {
        PlayClip(closeClip);
    }

    void PlayClip(AnimationClip clip)
    {
        if (anim != null && clip != null)
        {
            string clipName = clip.name;

            if (!anim.GetClip(clipName))
            {
                anim.AddClip(clip, clipName);
            }

            anim.Play(clipName);
        }
        else
        {
            Debug.LogWarning("Missing Animation or Clip.");
        }
    }
}