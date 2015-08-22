

function validateIsim() {
    var isim = document.getElementById('isim').value;
    if (isim == "") {
        document.getElementById('isimLbl').innerHTML = 'Lütfen isminizi yazınız';
        return false;
    }
    else {
        document.getElementById('isimLbl').innerHTML = '*';
        return true;
    }

}

function validateSoyisim() {
    var soyisim = document.getElementById('soyisim').value;
    if (soyisim == "") {
        document.getElementById('soyisimLbl').innerHTML = 'Lütfen soyisminizi yazınız';
        return false;

    }
    else {
        document.getElementById('soyisimLbl').innerHTML = '*';
        return true;
    }
}

function validateEposta() {
    var eposta = document.getElementById('email').value;
    if (eposta == "") {
        document.getElementById('emailLbl').innerHTML = 'Lütfen eposta adresinizi yazınız'
        return false;
    }

    else {
        document.getElementById('emailLbl').innerHTML = '*';
        return true;
    }

}

function validatePassword() {
    var sifre = document.getElementById('password').value;
    if (sifre == "") {

        document.getElementById('sifreLbl').innerHTML = 'Lütfen geçerli bir şifre yazınız'
        return false;
    }
    else {
        document.getElementById('sifreLbl').innerHTML = '*';
        return true;
    }
}

function validatePassEq() {
    var sifre = document.getElementById('password').value;
    var sifre1 = document.getElementById('password1').value;

    if (sifre != sifre1) {
        //document.getElementById('sifreLbl').style.fontSize = 8;
        //document.getElementById('sifreLbl2').style.fontSize = 8;
        document.getElementById('sifreLbl').innerHTML = 'İki şifrenin de aynı olduğuna emin olunuz';
        document.getElementById('sifreLbl2').innerHTML = 'İki şifrenin de aynı olduğuna emin olunuz';

        return false;
    }
    else if (sifre == sifre1) {
        document.getElementById("sifreLbl2").innerHTML = "*";
    }




}

