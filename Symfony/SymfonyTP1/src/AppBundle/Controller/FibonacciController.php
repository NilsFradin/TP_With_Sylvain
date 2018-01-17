<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Console\Application;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\Console\Input\ArrayInput;
use Symfony\Component\Console\Output\BufferedOutput;
use Symfony\Component\HttpFoundation\Response;

use Symfony\Component\HttpKernel\KernelInterface;

class FibonacciController extends Controller
{
    /**
     * @Route("/fibonacci{number}")
     */
    public function fibonacciAction($number)
    {
        $fibonacci = function($n) use (&$fibonacci) {
            if (0 === $n || 1 === $n) {
                return $n;
            }

            return $fibonacci($n - 1) + $fibonacci($n - 2);
        };

        $result = $fibonacci($number);

        return new Response('<html><body>Result: '.$result.'</body></html>');
    }



















    /**
     * @Route("/fibonacciCalcul")
     */
    public function fibonacciCalculAction(KernelInterface $kernel)
    {
        $application = new Application($kernel);
        $application->setAutoExit(false);

        $input = new ArrayInput(array(
            'command' => 'fibonacci:calcul',
            // (optional) define the value of command arguments
            'number' => 8
        ));

        $output = new BufferedOutput();
        $application->run($input, $output);

        $content = $output->fetch();

        return new Response('<html><body>'.$content.'</body></html>');
    }
}