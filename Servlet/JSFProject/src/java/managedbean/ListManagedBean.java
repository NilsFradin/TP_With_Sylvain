package managedbean;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.util.ArrayList;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import model.ListProduct;
import model.Product;

/**
 *
 * @author syescassut1
 */
@ManagedBean(name="listBean")
@SessionScoped
public class ListManagedBean {

    private ListProduct listProduct = new ListProduct();
    
    public ArrayList<Product> getProducts() {
        return listProduct.getProducts();
    }
    
}
