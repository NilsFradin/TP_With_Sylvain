<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of AppFixtures
 *
 * @author syescassut1
 */
namespace AppBundle\DataFixtures\ORM;

use AppBundle\Entity\Article;
use AppBundle\Entity\Categorie;
use AppBundle\Entity\User;
use Doctrine\Bundle\FixturesBundle\Fixture;
use Doctrine\Common\Persistence\ObjectManager;
use Faker;

class AppFixtures extends Fixture
{
    public function load(ObjectManager $manager)
    {
        $faker = Faker\Factory::create ();
        
        $categorie1 = new Categorie();
        $categorie1->setLibelle("Sport");
        $categorie1->setCouleur("Rouge");
        $manager->persist($categorie1);
        
        $categorie2 = new Categorie();
        $categorie2->setLibelle("Divertissement");
        $categorie2->setCouleur("Bleu");
        $manager->persist($categorie2);
        
        // create 10 articles!
        for ($i = 0; $i < 10; $i++) {
            $article = new Article();
            $article->setTitre($faker->realText($maxNbChars = 100, $indexSize = 2));
            $article->setDescription($faker->text);
            $article->setParution($faker->dateTimeBetween($startDate = '-2 years', $endDate = 'now', $timezone = null));
            $article->setActif($faker->boolean);
            if($i < 5) {
                $article->setCategories(array($categorie1));
            } else {
                $article->setCategories(array($categorie2));
            }
            $manager->persist($article);
        }
        
        $user1 = new User();
        $user1->setUsername("user1");
        $user1->setEmail("user1@gmail.com");
        $user1->setPlainPassword("user1");
        $user1->addRole('ROLE_USER');
        $user1->setEnabled(true);
        $manager->persist($user1);
        
        $user2 = new User();
        $user2->setUsername("user2");
        $user2->setEmail("user2@gmail.com");
        $user2->setPlainPassword("user2");
        $user2->addRole('ROLE_ADMIN');
        $user2->setEnabled(true);
        $manager->persist($user2);
        
        $manager->flush();
    }
}
