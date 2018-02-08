<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use \AppBundle\Entity\Article;

class DefaultController extends Controller
{   
    /**
     * @Route("/", name="homepage")
     */
    public function indexAction(Request $request)
    {
        $user = $this->getUser();        
        if(empty($user)){
            return $this->redirectToRoute("fos_user_security_login");
        }

        $articles = $this->getDoctrine()
            ->getRepository('AppBundle:Article')
            ->findAll();

        return $this->render('default/index.html.twig',
            array('articles' => $articles)
        );
    }
    
    /**
     * @Route("/sport", name="sport")
     */
    public function sportAction(Request $request)
    {
        $user = $this->getUser();        
        if(empty($user)){
            return $this->redirectToRoute("fos_user_security_login");
        }
        
        $categorie = $this->getDoctrine()
            ->getRepository('AppBundle:Categorie')
            ->findOneByLibelle("Sport");
       
        $articles = $categorie->getArticles();

        return $this->render('default/sport.html.twig',
            array('articles' => $articles)
        );
    }
    
    /**
     * @Route("/divertissement", name="divertissement")
     */
    public function divertissementAction(Request $request)
    {
        $user = $this->getUser();        
        if(empty($user)){
            return $this->redirectToRoute("fos_user_security_login");
        }
        
        $categorie = $this->getDoctrine()
            ->getRepository('AppBundle:Categorie')
            ->findOneByLibelle("Divertissement");
        
        $articles = $categorie->getArticles();

        return $this->render('default/divertissement.html.twig',
            array('articles' => $articles)
        );
    }
    
    /**
     * @Route("/addArticle", name="addArticle")
     */
    public function addArticlePageAction(Request $request)
    {      
        $article = new Article();

        $categories = $this->getDoctrine()
            ->getRepository('AppBundle:Categorie')
            ->findAll();
        
        $form = $this->createFormBuilder($article)
            ->add('titre', TextType::class)
            ->add('description', TextareaType::class)
            ->add('parution', DateType::class)
            ->add('actif', IntegerType::class)
            ->add('categories')
            ->add('save', SubmitType::class, array('label' => 'Create Article'))
            ->getForm();
        
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $article = $form->getData();
        }
        
        return $this->render('default/articleForm.html.twig',
            array('form' => $form)
        );
    }
}
