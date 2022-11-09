using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LP.TurnBasedStratey
{
    public class GameController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject Player = null;
        [SerializeField] private GameObject Enemy = null;
        [SerializeField] private Slider PlayerHealth = null;
        [SerializeField] private Slider EnemyHealth = null;
        [SerializeField] private Button FightBTN = null; 
        [SerializeField] private Button HealBTN = null;
        [SerializeField] private Button BlockBTN = null;
        [SerializeField] private States.StatesforMachine playerState;
        [SerializeField] private States.StatesforMachine enemyState;
        [SerializeField] private TMP_Text enemyStateText;
        #endregion
        #region Players Bool
        private bool isPlayersturn = true;
        #endregion
        #region States
        private void Start()
        {
            playerState = States.StatesforMachine.Heal;
            enemyState = States.StatesforMachine.Heal;

            enemyStateText.text = enemyState.ToString();

        }
        #endregion
        #region Fight option
        private void Fight(GameObject target, float damage)
        {
            if (target == Enemy)
            {
                playerState = States.StatesforMachine.Fight;

                if (enemyState != States.StatesforMachine.Block)
                {
                    EnemyHealth.value -= damage;
                }
              
            }
            else
            {
                
                enemyState = States.StatesforMachine.Fight;

                if(playerState != States.StatesforMachine.Block)
                {
                    PlayerHealth.value -= damage;
                }

            }
          
        }
        #endregion
        #region Heal Option
        private void Heal(GameObject target, float amount)
        {
            if (target == Enemy)
            {
                enemyState = States.StatesforMachine.Heal;
                EnemyHealth.value += amount;
            }
            else
            {
                 playerState = States.StatesforMachine.Heal;
                PlayerHealth.value += amount;
            }
            
        }
        #endregion
        #region Block Option
        private void Block(GameObject target, float avoid)
        {
            
            if (target = Player)
            {
                playerState = States.StatesforMachine.Block;
               
            }
            else
            {
                enemyState = States.StatesforMachine.Block;
            }
            
        }
        #endregion
        #region Buttons
        public void BtnFight()
        {
            Fight(Enemy, 10);
            ChangeTurn();
        }
        public void BtnHeal()
        {
            Heal(Player, 5);
            ChangeTurn();
        }
        public void BtnBlock()
        {
            Block(Player, 1);
            ChangeTurn();
        }
        #endregion

        #region Changing turns function
        private void ChangeTurn()
        {
            isPlayersturn = !isPlayersturn;
            
            if (!isPlayersturn)
            {
                StartCoroutine(Enemyturn());
                FightBTN.interactable = false;
                HealBTN.interactable = false;
                BlockBTN.interactable = false;

               
            }
            else
            {
                
                FightBTN.interactable = true;
                HealBTN.interactable = true;
                BlockBTN.interactable = true;
            }
        }
        #endregion
        #region Enemys Turn
        private IEnumerator Enemyturn()
        {
           

            int random = 0;
            random = Random.Range(1 , 4);
            Debug.Log(random);

         
            switch (random)
            {
                case 1:
                    enemyStateText.text = "Fight";
                    Fight(Player, 9);
                    break;
                case 2:
                    enemyStateText.text = "Heal";
                    Heal(Enemy, 4);
                    break;
                case 3:
                    enemyStateText.text = "Block";
                    Block(Enemy, 1);
                    break;
                default:
                    
                    break;
            }
            yield return new WaitForSeconds(1);
            ChangeTurn();

        }
        #endregion
    }
}


