/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package services;

/**
 *
 * @author syescassut1
 */
public class CheckFaultBean {
    
    private String message;
    
    public CheckFaultBean(String message){
        this.message = message;
    }
    
    public String getMessage(){
        return message;
    }
}
