using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // ’e‚ªÕ“Ë‚µ‚½‚Ìˆ—
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // •Ç‚ÉÕ“Ë‚µ‚½‚©‚ğŠm”F
        if (collision.CompareTag("Wall"))
        {
            // ’e‚Æ•Ç‚ğÁ‚·
            Destroy(gameObject); // ©•ª©g(’e)‚ğÁ‚·
          
        }
    }
}
