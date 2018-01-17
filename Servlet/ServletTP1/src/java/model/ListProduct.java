/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import java.util.ArrayList;

/**
 *
 * @author syescassut1
 */
public class ListProduct {
    
    public static ArrayList<Product> products = new ArrayList<Product>(){{
        add(new Product(1, "Smarties", 2));
        add(new Product(2, "Mac", 200000));
    }};
    
    public void addProduct(Product p) {
        products.add(p);
    }

    public ArrayList<Product> getProducts() {
        return products;
    }
}
