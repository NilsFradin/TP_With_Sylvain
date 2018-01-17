<?php

namespace AppBundle\Command;

use Symfony\Component\Console\Command\Command;
use Symfony\Component\Console\Input\InputArgument;
use Symfony\Component\Console\Input\InputInterface;
use Symfony\Component\Console\Output\OutputInterface;

class FibonacciCommand extends Command {

    protected function configure() {
        $this->setName("fibonacci:calcul")
            ->setDescription("Blabla")
            ->setHelp("Blabla")
            ->addArgument('number', InputArgument::REQUIRED, 'The number for the calcul of fibonacci');
    }

    protected function execute(InputInterface $in, OutputInterface $out) {
        $fibonacci = function($n) use (&$fibonacci) {
          if (0 === $n || 1 === $n) {
             return $n;
          }

          return $fibonacci($n - 1) + $fibonacci($n - 2);
        };

        $out->writeln($fibonacci($in->getArgument('number')));
    }
}