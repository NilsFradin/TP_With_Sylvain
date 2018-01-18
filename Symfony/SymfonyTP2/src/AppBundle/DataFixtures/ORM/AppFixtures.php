<?php

/**
 * Created by PhpStorm.
 * User: syescassut1
 * Date: 18/01/18
 * Time: 15:47
 */

namespace AppBundle\DataFixtures;

use AppBundle\Entity\Bibliotheque;
use AppBundle\Entity\Livre;
use Doctrine\Bundle\FixturesBundle\Fixture;
use Doctrine\Common\Persistence\ObjectManager;

class AppFixtures extends Fixture
{
    public function load(ObjectManager $manager)
    {
        $bibliotheque = new Bibliotheque();
        $bibliotheque->setNom("Bibi");
        $bibliotheque->setDirecteur("Dédé");
        $bibliotheque->setAdresse("36 rue de Roger");
        $manager->persist($bibliotheque);

        for ($i = 1; $i <= 10; $i++) {
            $livre = new Livre();
            $livre->setTitre("Tom-tom et nana à la plage - Chapitre ".$i);
            $livre->setAuteur("????");
            $livre->setBibliotheque($bibliotheque);
            $manager->persist($livre);
        }

        $manager->flush();
    }
}