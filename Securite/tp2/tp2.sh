#!/bin/bash
cat phpbb.txt | while read ligne ; do
	testBaba=$(openssl passwd -1 -salt BABA $ligne)
	testCaca=$(openssl passwd -1 -salt CACA $ligne)
	
	if [ $testBaba = '$1$BABA$DOzBWHNx08SgVSX/YuYvC/' ]
	then
		echo "Trouver : BABA DOzBWHNx08SgVSX/YuYvC/" + $ligne 
	fi
	if [ $testCaca = '$1$CACA$XLWo4OqFFCYICqYrZ0y5i/' ]
	then
		echo "Trouver : CACA XLWo4OqFFCYICqYrZ0y5i/" + $ligne 
	fi
done
