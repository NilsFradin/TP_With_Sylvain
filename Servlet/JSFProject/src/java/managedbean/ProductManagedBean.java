/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package managedbean;

import java.util.ArrayList;
import javax.faces.bean.ManagedBean;import javax.faces.bean.SessionScoped;
import model.Product;
;

/**
 *
 * @author syescassut1
 */
@ManagedBean(name="productBean")
@SessionScoped
public class ProductManagedBean {

    private Product selected;
    
    public String goProductPage(Product product) {
        this.selected = product;
        return "product";
    }
    
    public String updateProduct() {
        return "list";
    }

    public Product getSelected() {
        return selected;
    }
}
