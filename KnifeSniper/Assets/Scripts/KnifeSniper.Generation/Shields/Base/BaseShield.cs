using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeSniper.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] shieldMovementStep;

        [SerializeField]
        protected SpriteRenderer spriteRenderer;

        private UnityAction onShieldHit;
        private UnityAction onWin;

        [SerializeField]
        private int knifesToWin;
        public int KnifesToWin => knifesToWin;

        private List<BaseKnife> knifesInShield = new List<BaseKnife>();

        public abstract void Rotate();
        public virtual void Initialize(UnityAction onShieldHitCallback, UnityAction onWinCallback)
        {
            onShieldHit = onShieldHitCallback;
            onWin = onWinCallback;
        }

        public virtual void Dispose()
        {
            for (int i = 0; i < knifesInShield.Count - 1; i++)
            {
                BaseKnife knife = knifesInShield[i];
                Destroy(knife.gameObject);
                knifesInShield.Remove(knife);
            }

            knifesInShield.Clear();
            onShieldHit = null;
            onWin = null;

            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var knife = collision.GetComponentInParent<BaseKnife>();
            knife.RigidBody.velocity = Vector2.zero;
            knife.RigidBody.isKinematic = true;
            knife.transform.position = new Vector3(0f, -1.3f, 0f);
            knife.transform.SetParent(this.transform);
            knifesInShield.Add(knife);
            
            onShieldHit.Invoke();
            if (knifesToWin == knifesInShield.Count)
            {
                onWin.Invoke();
            }    
        }
    } 
}
