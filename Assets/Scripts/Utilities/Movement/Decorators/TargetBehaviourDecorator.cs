// Marc King - mjking@umich.edu

public abstract class TargetBehaviourDecorator : ActiveBehaviourDecorator
{
    new TargetBehaviour behaviour;

    public TargetBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour)
    {
        this.behaviour = behaviour as TargetBehaviour;
        this.agent = parentBehaviour.agent;
    }

    protected bool DeleteIfTargetNull()
    {
        return behaviour.deleteWhenNull && behaviour.target == null;
    }
}
