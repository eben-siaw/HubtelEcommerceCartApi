using System.Collections;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HubtelEcommerceCartApi.Controllers
{
    [ApiController]
    public class CartController : ControllerBase 
    {
        private readonly ILogger<CartController> _logger; 
        
        //Cart Service Interface
        public ICartService _cartservice;

        public CartController(ILogger<CartController> logger, ICartService cartservice)
        {
            _logger = logger; 
            _cartservice = cartservice;
        } 
        
       // ActionResults<T> to return a specific type or return a type from an action result
     

        // add to cart Route attribute 
        [HttpPost]
        [Route("addToCart")] 
        public ActionResult<string> AddToCart(Product product) {  
           
          if(_cartservice == null) { 
            return NotFound();
          }

          var results = _cartservice.AddToCart(product); 

          return results;
        }
         
        // remove from cart Route attribute
        [HttpDelete] 
        [Route("removeCart/{id}")]
        public ActionResult<string> RemoveFromCart(int id)
        { 
          if(_cartservice == null) { 
            return NotFound();
          }

          var results = _cartservice.RemoveItemFromCart(id);

          return results;
        } 
        
        //get cart list Route attribute
        [HttpGet] 
        [Route("getCartList")] 
        public ActionResult<IEnumerable<Product>> CartList() { 

          if(_cartservice == null) { 
            return NotFound();
          }

          var results = _cartservice.getCartList().ToList();

          return results;
        }  
        
        // get number of items in cart Route attribute
        [HttpGet] 
        [Route("count")]
        public ActionResult<int> getCartCount() {  
          if(_cartservice == null) { 
            return NotFound();
          }

          var results = _cartservice.getCartTotalItemCount(); 

          return results;
        } 
         
        // get single item in cart Route attribute 
        [HttpGet] 
        [Route("singleCart/{id}")]
        public ActionResult<Product> SingleCartItem(int id) { 
          if(_cartservice == null) { 
            return NotFound();
          }

          var results = _cartservice.getCartSingleItem(id);

          return results;
        }
    }
}

/* By Ebenezer */