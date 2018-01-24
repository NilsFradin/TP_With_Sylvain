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
use Doctrine\Bundle\FixturesBundle\Fixture;
use Doctrine\Common\Persistence\ObjectManager;
use Faker;

class AppFixtures extends Fixture
{
    public function load(ObjectManager $manager)
    {
        $faker = Faker\Factory::create ();
        // create 10 articles!
        for ($i = 0; $i < 10; $i++) {
            $article = new Article();
            $article->setTitre($faker->realText($maxNbChars = 100, $indexSize = 2));
            $article->setDescription($faker->text);
            $article->setParution($faker->dateTimeBetween($startDate = '-2 years', $endDate = 'now', $timezone = null));
            $article->setActif($faker->boolean);
            $manager->persist($article);
        }

        $manager->flush();
    }
}
