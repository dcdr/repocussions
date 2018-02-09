pipeline {
    agent { docker 'microsoft/aspnetcore-build:2.0' }
    stages {
        stage('build') {
            steps {
                bat 'dotnet build' 
            }
        }
        stage('test') {
            steps {
                bat 'dotnet test one.test'
            }
        }
        stage('containerize') {
            steps {
                bat 'docker build -t one:{BUILD_NUMBER} one'
            }
        }
    }
}