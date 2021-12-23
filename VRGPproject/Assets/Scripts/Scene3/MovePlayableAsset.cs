using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class MovePlayableAsset : PlayableAsset
{
    public ExposedReference<Transform> targetTransform;
    public Vector3 position;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        MovePlayableBehaviour playableBehaviour = new MovePlayableBehaviour();
        playableBehaviour.targetTransform = targetTransform.Resolve(graph.GetResolver());
        playableBehaviour.position = position;

        return ScriptPlayable<MovePlayableBehaviour>.Create(graph, playableBehaviour);
    }
}
