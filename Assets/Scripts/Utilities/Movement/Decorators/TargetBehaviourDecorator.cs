// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using System;

public abstract class TargetBehaviourDecorator : ActiveBehaviourDecorator
{
    new TargetBehaviour behaviour;
     
    public TargetBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour) 
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as TargetBehaviour; }

    protected bool DeleteIfTargetNull()
    {
        return behaviour.DeleteWhenNull && behaviour.TargetTransform == null;
    }
}
