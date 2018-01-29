/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.Callable;

/**
 *
 * @author syescassut1
 */
public class WebVerif implements Callable<Integer> {
    
    private String site;
    
    public WebVerif(String site) {
        this.site = site;
    }

    @Override
    public Integer call() throws Exception {
        Integer status;
        URL url = new URL(site);
        HttpURLConnection httpURLConnection = (HttpURLConnection)url.openConnection();
        httpURLConnection.connect();
        status = httpURLConnection.getResponseCode();   
        return status;
    }
}
