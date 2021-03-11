using System;
using System.Collections;
using System.Collections.Generic;using Abstracts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileView : ProjectileViewElement
{
    private Action<ProjectileViewElement> _onProjectileHitCeiling;
    private Action<ProjectileViewElement> _onProjectileHitBall;

    public override void Inject(PlayerControllerElement injection)
    {
        _onProjectileHitCeiling += injection.ProjectileHitCeiling;
        _onProjectileHitBall += injection.ProjectileHitBall;
    }

    protected override void OnHitCeiling()
    {
        _onProjectileHitCeiling?.Invoke(this);
    }

    protected override void OnHitBall()
    {
        _onProjectileHitBall?.Invoke(this);
    }

}
