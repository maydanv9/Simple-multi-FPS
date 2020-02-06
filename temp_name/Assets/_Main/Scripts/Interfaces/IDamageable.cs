using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void GetDamage(int damageValue);
    void GetHeal(int healValue);
}
