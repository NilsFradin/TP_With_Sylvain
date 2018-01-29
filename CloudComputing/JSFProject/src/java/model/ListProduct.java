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
    
    private ArrayList<Product> products;
    
    public ListProduct() {
        this.products = new ArrayList<Product>(){{
            add(new Product(1, "mac", 200000));
            add(new Product(2, "smarties", 2));
        }};
    }
    
    public ArrayList<Product> getProducts() {
        return this.products;
    }
}
