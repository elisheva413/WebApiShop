
const extrctDataFromInput = () => {
    const userName = document.querySelector("#userName").value
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value
    return { userName, firstName, lastName, password }
}

const createObjUser = (upDateValues) => {
    const id = 1
    const userName = upDateValues.userName
    const firstName = upDateValues.firstName
    const lastName = upDateValues.lastName
    const password = upDateValues.password
    return { id, userName, firstName, lastName, password }
}

const updateStorage = (fullUser) => {
    sessionStorage.setItem("userName", fullUser.userName)
    sessionStorage.setItem("firstName", fullUser.firstName)
    sessionStorage.setItem("lastName", fullUser.lastName)
    sessionStorage.setItem("password", fullUser.password)
    sessionStorage.setItem("id",fullUser.id)
}

async function postResponse() {
    const dateValues = extrctDataFromInput()
    const newUser = createObjUser(dateValues)
    try {
        const response = await fetch(
            "api/Users",
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newUser)
            }
        )
        if (!response.ok) {
            throw new Error(`HTTP error! status ${response.status}`);
        }
        else {
            alert("המשתמש נרשם בהצלחה")
        }
    }
    catch (e) { alert(e) }
}

async function logIn() {
    const userName = document.querySelector("#username").value
    const password = document.querySelector("#pasword").value
    const existUser = { userName, password }
    try {
        const response = await fetch(
           
            "api/Users/login",
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(existUser)
            }
        )
        if (!response.ok) {
            alert("שם משתמש או סיסמא שגויים")
            throw new Error(`HTTP error! status ${response.status}`);
        }
        else {
            const fullUser = await response.json()
            updateStorage(fullUser)
            window.location.href = "page2.html"
        }
    }
    catch (e) { }
}


