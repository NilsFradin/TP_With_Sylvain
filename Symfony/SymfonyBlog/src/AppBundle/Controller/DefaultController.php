<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use \AppBundle\Entity\Article;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\TextareaType;
use Symfony\Component\Form\Extension\Core\Type\DateType;
use Symfony\Component\Form\Extension\Core\Type\IntegerType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;

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
    public function addArticleAction(Request $request)
    {      
        $user = $this->getUser();        
        if(empty($user)){
            return $this->redirectToRoute("fos_user_security_login");
        }
        if($user->getRoles()[0] != 'ROLE_ADMIN') {
            return $this->redirectToRoute("homepage");
        }            
            
        $article = new Article();
        
        $form = $this->createFormBuilder($article)
            ->add('titre', TextType::class, array('attr' => array('class' => 'form-control')))
            ->add('description', TextareaType::class, array('attr' => array('class' => 'form-control')))
            ->add('parution', DateType::class, array('attr' => array('class' => 'form-control')))
            ->add('actif', IntegerType::class, array('attr' => array('class' => 'form-control')))
            ->add('categories')
            ->add('save', SubmitType::class, array('label' => 'Create Article', 'attr' => array('class' => 'btn')))
            ->getForm();
        
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $article = $form->getData();
            $em = $this->getDoctrine()->getManager();
            $em->persist($article);
            $em->flush();
            return $this->redirectToRoute("homepage");
        }
        
        return $this->render('default/articleForm.html.twig',
            array('form' => $form->createView())
        );
    }
}
