using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class SmallEnemy: GameObject
    {
        public static int maxHealth = 1;
        private int _currentHealth;
        public SmallEnemy()
        {
            maxHealth = EnemyManager.smallEnemyDeathCounter/10;
            if(maxHealth <= 0)
            {
                maxHealth = 1;
            }
            _currentHealth = maxHealth;
        }

        public void ReciveDamage(int damageAmount, Position attackPosition)
        {
            _currentHealth -= damageAmount;
            if(_currentHealth <=0)
            {
                EnemyManager.SmallEnemyRewards();
                EnemyManager.smallEnemyDeathCounter++;
                EnemyManager.smallEnemyList.Remove(this);
                GameManager.map.mapArray[attackPosition.y, attackPosition.x].type = Type.Empty;
            }
            else
            {
                Hud.InfoText2 = "Small enemy Still Alive";
            }
        }
    }
}
