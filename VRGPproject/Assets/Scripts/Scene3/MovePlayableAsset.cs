using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class MovePlayableAsset : PlayableAsset
{
    public ExposedReference<Transform> targetTransform;
    public Vector3 startPosition;
    public Vector3 endPosition;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        ScriptPlayable<MovePlayableBehaviour> playable = ScriptPlayable<MovePlayableBehaviour>.Create(graph);
        MovePlayableBehaviour playableBehaviour = playable.GetBehaviour();
        playableBehaviour.targetTransform = targetTransform.Resolve(graph.GetResolver());
        // playableBehaviour.position = position;

        return playable;
    }
}
