pipeline {
    agent { docker 'microsoft/aspnetcore-build:2.0' }
    stages {
        stage('build') {
            steps {
               sh 'dotnet build' 
            }
        }
        stage('test') {
            steps {
               sh 'dotnet test one.test'
            }
        }
        stage('containerize') {
            steps {
                script {
                   docker.build(one, "-t one:${env.BUILD_NUMBER}) .") 
                }
            }
        }
    }
}
