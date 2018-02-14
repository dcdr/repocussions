pipeline {
    agent { docker 'microsoft/aspnetcore-build:2.0' }
    stages {
        stage('context') {
            steps {
                sh 'pwd;find .;ls ..;ls ../..'
                sh 'ls ../*@script'
            }
        }
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
        // stage('containerize') {
        //     steps {
        //         script {
        //            def image = docker.build(one, "-t one:${env.BUILD_NUMBER} .") 
        //         }
        //     }
        // }
    }
}
