using System.Threading.Tasks;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;

// defining the Cartservice class taking in a constructor and the public methods 
// The cart service class derives from the cart service interface
namespace HubtelEcommerceCartApi.Services
{
  
public class CartService: ICartService { 
     
// instantiate an instance of the List class with the new keyword 
// which is done in the constructor  
// List represents a collection of objects that can be accessed by index
    public List<Product> _cart;

    public CartService() { 
      _cart = new List<Product>(); 
    } 
    
    // ADD TO CART method
    public string AddToCart(Product product) { 
     // check if the incoming product id matches the id in the existing cart list  

     // if item exists in cart then increases the quantity by 1 

     // else add the new item to the cart
      var isProductExist = _cart.Find((item) => item.Id == product.Id);

      if(isProductExist != null) { 

        isProductExist.product_quantity++;   
        
        return "Item exists already in Cart, quantity increased";
      } 

      if(product.product_quantity < 0) {
        // product.product_quantity = 1;       
          return "Quantity cannot be negative"; 
      } 
      
      _cart.Add(product);   
      return "New Items Added to cart"; 
    }  
    
    // REMOVE FROM CART method
    public string RemoveItemFromCart(int productId) {  

      // single or default linq function returns a specified element in the List 

      // I returned the cart item where the id of the item matches the id from the url 

      // if the item exists then remove the item from cart
       
      var cartItem = _cart.SingleOrDefault((item) => item.Id == productId);

        if(cartItem != null) { 
        
         _cart.Remove(cartItem);

         return "Item successfully removed from cart"; 
       } 

      return "Could not find Cart item to be removed";
    }
    
    // GET CART LIST 
    public IEnumerable<Product> getCartList() {  
      // returns the list of items in the cart
     return _cart;
    }  

    // GET THE NUMBER OF ITEMS IN CART
    public int getCartTotalItemCount(){ 
     return _cart.Count;
    }

    // RETRIEVE SINGLE ITEM IN THE CART
    public Product getCartSingleItem(int productId) { 
      // get a single cart item
    return _cart.FirstOrDefault((item) => item.Id == productId); 
      
    }
  } 

}