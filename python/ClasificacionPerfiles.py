import sys
import numpy as np

##################### TRAINING ######################
def dictionary(data):
    dic = []
    for i in data:
        dic = sorted(list(set(dic+i)))  # Appends each item without repeating
    return dic
    
def word2vec_train(dic, data):
    new_data = np.zeros((len(data),len(dic)), dtype=int)
    for i in range(len(new_data)):
        person = data[i]
        for tech in person:
            new_data[i][dic.index(tech)]=1
    return new_data

################## CLASSIFICATION ###################
def word2vec_single(dic, tech):
    vec = np.zeros(len(dic), dtype=int)
    for word in tech:
        vec[dic.index(word)]=1
    return vec
         
def classify(vec, new_data):
    compare = new_data+vec
    compare[compare<2] = 0
    result_arr = sum(compare.T)
    print(compare)
    print(result_arr)
    return np.argwhere(result_arr == max(result_arr)) # return training data indexes with the lowest value

# Show the result in a good way
# Input: List of lists
# Output: Print with the results
def deploy_result(result, labels):
    print("Los ID de los elegidos son:")
    for i in result:
        print(labels[i[0]])
        
    
    
def main():
    # Training data (People)
    data = [['SQL', 'MongoDB', 'Java', 'Python'],
            ['Python', 'Oracle', 'C#', 'Java'],
            ['C', 'SQL', 'Oracle', '.Net', 'Django', 'Flask', 'Python'],
            ['Flask', 'Python', 'C++', 'Ensamblador', 'Oracle']
           ]
    labels =[114650899,456789876,801340133,298730144] # People ID

    # Training 
    dic = dictionary(data)
    print("Tecnologías:\n",dic,'\n')
    new_data = word2vec_train(dic, data)
    print("Datos vectorizados:\n",new_data,'\n')

    # Classification
    tech = ['Oracle', 'Java']
    vec = word2vec_single(dic, tech)
    print("Tecnologias necesarias:\n",tech,'\n')
    print("Tecnologias vectorizadas\n",vec,'\n')
    result = classify(vec, new_data)
    deploy_result(result, labels)    
    
main()

#people_tech, id_labels, tech_needed = sys.argv[1], sys.argv[2], sys.argv[3]
#main(people_tech, id_labels, tech_needed)
