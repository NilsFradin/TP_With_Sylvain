#include <gmp.h>
#include <stdio.h>
#include <assert.h>

int main() {
	char inputStr[1024];
	
	mpz_t n;
	int flag;
	
	mpz_t phi, e, c, encryption;
	//mp_limb_t *p, *q;
	mpz_t p, q;
	
	mpz_t i;
	
	mpn_urandomb(p, 4096);
	mpn_urandomb(q, 4096);
	
	printf("Entrez un nombre : ");
	scanf("%1023s", inputStr);
	
	mpz_init(n);
	mpz_set_ui(n, 0);
	
	mpz_mul(n, p, q);
	
	mpz_mul(phi, p-1, q-1);

	mpz_gcd_1(e, phi, 1);

	printf("Entrez un message : ");
	scanf("%1023s", inputStr);
	
	mpz_pown(c, inputStr, e, n);
	
	/*
	printf("(n + 1)^2 = ");
	mpz_out_str(stdout, 10, n);
	printf("\n");*/
	
	mpz_clear(n);

	return 0;
}
