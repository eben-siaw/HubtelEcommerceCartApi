using System.Threading.Tasks;
using System.Collections.Generic;

public interface ICartService {
   // unimplemented methods of which the cart service class inherits
  // abstract methods declarations 

  string AddToCart(Product product); 

  IEnumerable<Product> getCartList(); 

  Product getCartSingleItem(int productId); 

  string RemoveItemFromCart(int productId); 

  int getCartTotalItemCount();
}