using UnityEngine;

public class PatrolState : EnemyState
{
    private int _pointNumber = 0;

    private readonly Transform[] _points;
    private readonly float _speed = 3f;

    public PatrolState(Enemy enemy, EnemyStateMachine enemyStateMachine, Transform[] points) : base(enemy, enemyStateMachine)
    {
        _points = points;
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.SetDirection(_points[_pointNumber].position);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        if (enemy.transform.position == _points[_pointNumber].position)
            _pointNumber = ++_pointNumber % _points.Length;

        enemy.SetDirection(_points[_pointNumber].position, _speed);
    }
}