const config = {
    server: 'localhost',
    authentication: {
        type: 'default',
        opitions: {
            userName: 'sa',
            password: 'teste123'
        }
    },
    options: {
        encrypt: false,
        database: 'Lojas'
    },
    port: 50666
}

module.exports = config;