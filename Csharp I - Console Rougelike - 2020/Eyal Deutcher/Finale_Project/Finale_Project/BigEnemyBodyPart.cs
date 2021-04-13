using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class BigEnemyBodyPart:GameObject
    {
        public static int maxHealth = 1;
        int _currentHealth;
        public BigEnemyBodyPart()
        {
            maxHealth = EnemyManager.bigEnemyDeathCounter / 2;
            if(maxHealth <=0)
            {
                maxHealth = 1;
            }
            _currentHealth = maxHealth;
        }
        public void reciveDamage(int damageAmount, BigEnemy bigEnemy)
        {
            _currentHealth -= damageAmount;
            if(_currentHealth <=0)
            {
                bigEnemy.bigEnemyPartList.Remove(this);
                GameManager.map.mapArray[position.y, position.x].type = Type.Empty;
            }
            else
            {
                Hud.InfoText2 = "Big Enemy Part Has: " + _currentHealth + " health";
            }
        }
        public void DestroyBodyPart(BigEnemy bigEnemy)
        {
            bigEnemy.bigEnemyPartList.Remove(this);
        }
    }
}
