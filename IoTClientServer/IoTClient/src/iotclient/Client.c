#include <stdio.h>
#include <stdlib.h>
#include <netinet/in.h>
#include <netdb.h>
#include <sys/socket.h>
#include <string.h>

void main(int argc, char *argv[])
{
  char buffer[200],texte[200];
  char dest[200];
  int port, rc, sock,i,c, nombre;
  struct sockaddr_in addr;
  struct hostent *entree;

  if (argc !=3)  {
      printf("usage : client nom_serveur port\n");
	exit(1);    }
  
  addr.sin_port=htons(atoi(argv[2]));
  addr.sin_family=AF_INET;
  entree=(struct hostent *)gethostbyname(argv[1]);
  bcopy((char *)entree->h_addr,(char *)&addr.sin_addr,entree->h_length);
    
  sock= socket(AF_INET,SOCK_STREAM,0);

  if (connect(sock, (struct sockaddr *)&addr,sizeof(struct sockaddr_in)) < 0) {
    printf("probleme connexion\n");
    exit(1); }

  printf("connexion passe\n");

  while (1) {
      bzero(texte,sizeof(texte)); 
      bzero(buffer,sizeof(buffer));     
      i = 0;
      printf("Entrez une ligne de texte : \n");
      while((c=getchar()) != '\n')
		texte[i++]=c;
		
	  if (strcmp("FIN",texte) == 0)	break;
	  
	  printf("Tapez 1 pour le nombre de mots\n");
	  printf("Tapez 2 pour le nombre de lettres\n");
	  scanf("%d", &nombre);
	  
	  if(nombre == 1) {
		  strcpy(dest, "1: ");
		  strcat(dest, texte);
		  strcat(dest, "\n");
	  } else if(nombre == 2) {
		  strcpy(dest, "2: ");
		  strcat(dest, texte);
		  strcat(dest, "\n");
	  } else {
		printf("Tapez 1 pour le nombre de mots\n");
		printf("Tapez 2 pour le nombre de lettres\n");
		scanf("%d", &nombre);
	  }

      send(sock,dest,strlen(dest)+1,0);
      recv(sock,buffer,sizeof(buffer),0);
      printf("recu %s\n",buffer);
      
      
      
      
    }

  close(sock); 
}
