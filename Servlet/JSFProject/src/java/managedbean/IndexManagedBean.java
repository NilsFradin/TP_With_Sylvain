package managedbean;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import javax.faces.bean.ManagedBean;

/**
 *
 * @author syescassut1
 */
@ManagedBean(name="indexBean")
public class IndexManagedBean {
    
    public String getMessage(){
        return "Hello World !";
    }
    
    public String goUserPage() {
        return "user";
    }
}
