<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Console\Application;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\Console\Input\ArrayInput;
use Symfony\Component\Console\Output\BufferedOutput;
use Symfony\Component\HttpFoundation\Response;
use AppBundle\Entity\Bibliotheque;
use AppBundle\Entity\Livre;
use Symfony\Component\HttpKernel\KernelInterface;

class BibliothequeController extends Controller
{
    /**
     * @Route("/listLivres")
     */
    public function listLivresAction()
    {
        $bibliotheques = $this->getDoctrine()
            ->getRepository(Bibliotheque::class)
            ->findAll();

        $livres = $this->getDoctrine()
            ->getRepository(Livre::class)
            ->findBy(array("bibliotheque" => $bibliotheques[0]->getId()));

        return $this->render(
            'listLivres.html.twig',
            array('bibliotheque' => $bibliotheques[0],
                'livres' => $livres
            )
        );
    }
}