/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejb;

import javax.ejb.Stateless;

/**
 *
 * @author syescassut1
 */
@Stateless
public class HelloService implements HelloServiceRemote {
    @Override
    public String sayHello(){
        return "Hello, World !";
    }
}

