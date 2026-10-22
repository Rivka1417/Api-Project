const title = document.getElementById("title")
const email = document.getElementById("email")
const password = document.getElementById("pass")
const fname = document.getElementById("fname")
const lname = document.getElementById("lname")


const user = JSON.parse(sessionStorage.getItem("user"))

title.textContent = `hello ${user.firstName}`
email.textContent = `user-email: ${user.email}`
password.value = user.password
fname.value = user.firstName
lname.value = user.lastName

const update = async () => {
    const updateData =
    {
        Email: user.email,
        Password: password.value,
        FirstName: fname.value,
        LastName: lname.value,
    }
    const responsePut = await fetch(`api/Login/${user.userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updateData)
    });
    if (responsePut.ok) {
        alert("הפרטים עודכנו בהצלחה")
    }
    else {
        alert(responsePut.status)
    }
}


