
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


    const responsePost = await fetch('api/Login', {
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

    const update = document.getElementById("update")

    const user = {
        Email: mail,
        Password: password,
    }


    const responsePost = await fetch('api/Login/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
    const dataPost = await responsePost.json()
    if (responsePost.ok) {
        sessionStorage.setItem("user",JSON.stringify(dataPost))
        alert("התחברת בהצלחה")
        update.style.display = "flex"
    }
    else {
        alert(responsePost.status)
    }
}
const l = document.querySelector(".register")
const Display = () => {
    l.style.display = "flex"
}