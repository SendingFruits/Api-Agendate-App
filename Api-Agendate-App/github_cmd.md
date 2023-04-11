Abrir el CMD como Admin siempre

1- Ir a la carpeta de la app
2- Comprobar si hay repositorio: git rev-parse --is-inside-work-tree
3- Si no hay, crearlo en la web de git: Botón verde [New], sino también se puede crear desde el CMD en la carpeta con: sudo git init  (para crear directorio .git)
5- Copiar el directorio: .github y el archivo .gitignore
6- Asociar URL: sudo git remote add origin https://github.com/......... .git
7- Comprobar si hay repositorio: git rev-parse --is-inside-work-tree 
     ---> si dice true: existe [en este caso, cambiarla]:

       7a- git remote -v   → visualizar las urls que hay
       7b- git remote rm origin  → borro las url con el nombre ‘origin’
       7c- hacer punto 6

8- sudo git add .
9- sudo git commit -m "first commit"
10- git push --set-upstream origin master
