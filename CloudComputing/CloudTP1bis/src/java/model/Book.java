/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author syescassut1
 */
@XmlRootElement(name="Book")
public class Book {
    
    protected String title;
    
    public Book(String title) {
        this.title = title;
    }
    
    public Book() { }
    
    public String getTitle() {
        return this.title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
    
    public String toString(){
        return this.title;
    }
}
