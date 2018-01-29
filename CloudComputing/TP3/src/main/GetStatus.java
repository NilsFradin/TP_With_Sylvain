/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.FutureTask;

/**
 *
 * @author syescassut1
 */
public class GetStatus {
    
    String[] hostList = { "http://crunchify.com", "http://yahoo.com",
        "http://www.ebay.com", "http://google.com",
        "http://www.example.co", "https://paypal.com",
        "http://bing.com/", "http://techcrunch.com/",
        "http://mashable.com/", "http://thenextweb.com/",
        "http://wordpress.com/", "http://wordpress.org/",
        "http://example.com/", "http://sjsu.edu/",
        "http://ebay.co.uk/", "http://google.co.uk/",
        "http://www.wikipedia.org/",
        "http://en.wikipedia.org/wiki/Main_Page"
    };
    ExecutorService executor = Executors.newFixedThreadPool(2);
    
    public void getStatusWebsites() {
        for(int i=0 ; i<hostList.length ; i++) {
            WebVerif webVerif = new WebVerif(hostList[i]);
            FutureTask<String> futureTask1 = new FutureTask<String>(callable1);
            executor.execute();
        }
    }
}
