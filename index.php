<!DOCTYPE html>
<html>
    <head>
        <style>
            .center {
                display: grid;
                place-items: center;
            }
        </style>
    </head>
<body>
    <div class = "center">
        <h2>Ursina register form:</h2>

        <form action="/register.php" method="post">
        <label for="fname">Username</label><br>
        <input type="text" name="username"><br>
        <label for="lname">password</label><br>
        <input type="password" name="password"><br><br>
        <input type="submit" value="Submit">
        </form> 
    </div>
</body>
</html>
