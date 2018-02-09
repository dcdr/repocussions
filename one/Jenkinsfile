pipeline {
    agent { docker 'microsoft/aspnetcore-build:2.0' }
    stages {
        stage('build') {
            steps {
                bat 'dotnet --version' 
            }
        }
    }
}