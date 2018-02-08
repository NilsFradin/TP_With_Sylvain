<?php

namespace AppBundle\Form;

use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\PasswordType;

class RegistrationType extends AbstractType
{
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $builder->add('username', TextType::class, array('label' => 'Pseudo : ', 'attr' => array('class' => 'form-control')))
            ->add('password', PasswordType::class, array('label' => 'Password : ', 'attr' => array('class' => 'form-control')));
    }

    public function getParent()
    {
        return 'FOS\UserBundle\Form\Type\RegistrationFormType';
    }

    public function getName()
    {
        return 'app_user_registration';
    }
}
