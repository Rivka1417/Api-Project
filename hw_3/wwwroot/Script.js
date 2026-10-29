
async function reg() { 

    const mail = document.getElementById("mail").value;

    const password = document.getElementById("pass").value

    const fname = document.getElementById("fname").value

    const lname = document.getElementById("lname").value

    

    const user = {
        Email: mail,
        Password: password,
        FirstName: fname,
        LastName: lname,
    }


    const responsePost = await fetch('api/users', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
        body: JSON.stringify(user)
});
    if (responsePost.ok) {
        alert("נרשמת בהצלחה")
    }
    else {
        alert(responsePost.status)
    }
}
async function log() {

    const mail = document.getElementById("usermail").value;

    const password = document.getElementById("pas").value


    const user = {
        Email: mail,
        Password: password,
    }


    const responsePost = await fetch('api/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
    const dataPost = await responsePost.json()
    if (responsePost.ok) {
        sessionStorage.setItem("user",JSON.stringify(dataPost))
        window.location.href ="Update.html"
    }
    else {
        alert(responsePost.status)
    }
}
const l = document.querySelector(".register")
const Display = () => {
    l.style.display = "flex"
}

const checkPass = async () => {

    const password = document.getElementById("pass").value
    let progress = document.getElementById("progress")
    progress.style.display="flex"

    const responsePost = await fetch('api/password', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });

    progress.value = await responsePost.text()
}